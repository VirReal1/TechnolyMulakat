import env from './.env';

export const environment = {
  production: true,
  serverUrl: 'https://localhost:7254/',
  hostUrl: 'https://localhost:44433/',
  version: env.npm_package_version + '-dev',
};
