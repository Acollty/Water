import type { ChannelDto, CreateUpdateChannelDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ChannelService {
  apiName = 'Default';

  create = (input: CreateUpdateChannelDto) =>
    this.restService.request<any, ChannelDto>({
      method: 'POST',
      url: '/api/app/channel',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/channel/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, ChannelDto>({
      method: 'GET',
      url: `/api/app/channel/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ChannelDto>>({
      method: 'GET',
      url: '/api/app/channel',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateChannelDto) =>
    this.restService.request<any, ChannelDto>({
      method: 'PUT',
      url: `/api/app/channel/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
