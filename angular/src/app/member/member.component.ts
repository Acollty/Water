import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { MemberService, MemberDto } from '@proxy/members';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class MemberComponent implements OnInit {

  member = { item:[],totalCount : 0} as PagedResultDto<MemberDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedMember = {} as MemberDto;

  constructor(

    public readonly list: ListService,
    private memberService: MemberService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService

  ) { }

  ngOnInit(): void{
    const memberStreamCreator = (query) => this.memberService.getList(query);

    this.list.hookToQuery(memberStreamCreator).subscribe((response) => {
      this.member = response;
    });
  }

  createMember() {
    this.selectedMember = {} as MemberDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editMember(id: string) {
    this.memberService.get(id).subscribe((member) => {
      this.selectedMember = member;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedMember.name || '', Validators.required],
      mobile: [this.selectedMember.mobile || '', Validators.required],
      email: [this.selectedMember.email || '', Validators.required],
      password: [this.selectedMember.password || '', Validators.required],
      birthDate: [
        this.selectedMember.birthDate ? new Date(this.selectedMember.birthDate) : null,
        Validators.required,
      ],
      gender: [this.selectedMember.gender || 0, Validators.required],
      shortBio: [this.selectedMember.shortBio || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedMember.id) {
      this.memberService
        .update(this.selectedMember.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.memberService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.memberService.delete(id).subscribe(() => this.list.get());
          }
        });
  }
}
