import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateRequirementDto {
  name: string;
  description: string;
  publishDate: string;
}

export interface RequirementDto extends AuditedEntityDto<string> {
  name?: string;
  description?: string;
  publishDate?: string;
}
