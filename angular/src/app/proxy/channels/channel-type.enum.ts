import { mapEnumToOptions } from '@abp/ng.core';

export enum ChannelType {
  Undefined = 0,
  Dedicated = 1,
  Public = 2,
}

export const channelTypeOptions = mapEnumToOptions(ChannelType);
