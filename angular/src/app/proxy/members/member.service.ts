import type { CreateMemberDto, GetMemberListDto, MemberDto, UpdateMemberDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  apiName = 'Default';

  create = (input: CreateMemberDto) =>
    this.restService.request<any, MemberDto>({
      method: 'POST',
      url: '/api/app/member',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/member/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, MemberDto>({
      method: 'GET',
      url: `/api/app/member/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetMemberListDto) =>
    this.restService.request<any, PagedResultDto<MemberDto>>({
      method: 'GET',
      url: '/api/app/member',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: UpdateMemberDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/member/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
