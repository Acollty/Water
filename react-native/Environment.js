const ENV = {
  dev: {
    apiUrl: 'http://localhost:44322',
    oAuthConfig: {
      issuer: 'http://localhost:44322',
      clientId: 'WaterCarriage_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access WaterCarriage',
    },
    localization: {
      defaultResourceName: 'WaterCarriage',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44322',
    oAuthConfig: {
      issuer: 'http://localhost:44322',
      clientId: 'WaterCarriage_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access WaterCarriage',
    },
    localization: {
      defaultResourceName: 'WaterCarriage',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
