import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import {RequirementService,RequirementDto} from '@proxy/requirements';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; // add this

// added this line
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-requirement',
  templateUrl: './requirement.component.html',
  styleUrls: ['./requirement.component.scss'],
  providers:[
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } // add this line
  ]
})
export class RequirementComponent implements OnInit {

  requirement = { items: [], totalCount: 0 } as PagedResultDto<RequirementDto>;

  selectedRequirement = {} as RequirementDto; // declare selectedBook

  form: FormGroup; // add this line

  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService,
    private requirementService: RequirementService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService
    ) {}

  ngOnInit() {
    const requirementStreamCreator = (query) => this.requirementService.getList(query);

    this.list.hookToQuery(requirementStreamCreator).subscribe((response) => {
      this.requirement = response;
    });
  }

    // add new method
    createRequirement() {
      this.selectedRequirement = {} as RequirementDto;
      this.buildForm(); // add this line
      this.isModalOpen = true;
    }

      // Add editBook method
  editRequirement(id: string) {
    this.requirementService.get(id).subscribe((requirement) => {
      this.selectedRequirement = requirement;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.requirementService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

    // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedRequirement.name || '', Validators.required],
      description: [this.selectedRequirement.description || '', Validators.required],
      publishDate: [this.selectedRequirement.publishDate ? new Date(this.selectedRequirement.publishDate) :null, Validators.required],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedRequirement.id ?
    this.requirementService.update(this.selectedRequirement.id,this.form.value) :
    this.requirementService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

}
