import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ChannelService, ChannelDto, channelTypeOptions } from '@proxy/channels';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; // add this
// added this line
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-channel',
  templateUrl: './channel.component.html',
  styleUrls: ['./channel.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } // add this line
  ],
})
export class ChannelComponent implements OnInit {

  channel = { items: [], totalCount: 0 } as PagedResultDto<ChannelDto>;

  selectedChannel = {} as ChannelDto;

  form: FormGroup; // add this line

  // add channelTypes as a list of ChannelType enum members
  channelTypes = channelTypeOptions;

  isModalOpen = false; // add this line

  constructor(
    public readonly list: ListService,
    private channelService: ChannelService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) { }

  ngOnInit() {
    const channelStreamCreator = (query) => this.channelService.getList(query);

    this.list.hookToQuery(channelStreamCreator).subscribe((response) => {
      this.channel = response;
    });
  }

  // add new method
  createChannel() {
    this.selectedChannel = {} as ChannelDto;
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  // Add editBook method
  editChannel(id: string) {
    this.channelService.get(id).subscribe((channel) => {
      this.selectedChannel = channel;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // Add a delete method
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.channelService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedChannel.name || '', Validators.required],
      type: [this.selectedChannel.type || null, Validators.required],
      startTime: [this.selectedChannel.startTime ? new Date(this.selectedChannel.startTime) : null, Validators.required],
      endTime: [this.selectedChannel.endTime ? new Date(this.selectedChannel.endTime) : null, Validators.required],
      ports: [this.selectedChannel.ports || null, Validators.required],
    });
  }

  // add save method
  save() {
    console.log(this.form.invalid)
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedChannel.id
      ? this.channelService.update(this.selectedChannel.id, this.form.value)
      : this.channelService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

}
