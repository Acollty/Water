import type { CreateUpdateRequirementDto, RequirementDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RequirementService {
  apiName = 'Default';

  create = (input: CreateUpdateRequirementDto) =>
    this.restService.request<any, RequirementDto>({
      method: 'POST',
      url: '/api/app/requirement',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/requirement/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, RequirementDto>({
      method: 'GET',
      url: `/api/app/requirement/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<RequirementDto>>({
      method: 'GET',
      url: '/api/app/requirement',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateRequirementDto) =>
    this.restService.request<any, RequirementDto>({
      method: 'PUT',
      url: `/api/app/requirement/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
