import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateMemberDto {
  name: string;
  mobile: string;
  email: string;
  password: string;
  birthDate: string;
  gender: number;
  shortBio?: string;
}

export interface GetMemberListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface MemberDto extends EntityDto<string> {
  name?: string;
  mobile?: string;
  email?: string;
  password?: string;
  birthDate?: string;
  gender: number;
  shortBio?: string;
}

export interface UpdateMemberDto {
  name: string;
  mobile: string;
  email: string;
  password: string;
  birthDate: string;
  gender: number;
  shortBio?: string;
}
