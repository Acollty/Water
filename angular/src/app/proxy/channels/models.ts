import type { AuditedEntityDto } from '@abp/ng.core';
import type { ChannelType } from './channel-type.enum';

export interface ChannelDto extends AuditedEntityDto<string> {
  name?: string;
  type: ChannelType;
  startTime?: string;
  endTime?: string;
  ports: number;
}

export interface CreateUpdateChannelDto {
  name: string;
  type: ChannelType;
  startTime: string;
  endTime: string;
  ports: number;
}
