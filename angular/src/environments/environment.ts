import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'WaterCarriage',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44322',
    redirectUri: baseUrl,
    clientId: 'WaterCarriage_App',
    responseType: 'code',
    scope: 'offline_access WaterCarriage',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44322',
      rootNamespace: 'WaterCarriage',
    },
  },
} as Environment;
