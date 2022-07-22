import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/water-carriage',
        name: '::Menu:WaterCarriage',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/channels',
        name: '::Menu:Channels',
        parentName: '::Menu:WaterCarriage',
        layout: eLayoutType.application,
        requiredPolicy:"WaterCarriage.Channels"
      },
      {
        path: '/requirements',
        name: '::Menu:Requirements',
        parentName: '::Menu:WaterCarriage',
        layout: eLayoutType.application,
        requiredPolicy:"WaterCarriage.Requirements"
      },
      {
        path: '/members',
        name: '::Menu:Members',
        parentName: '::Menu:WaterCarriage',
        layout: eLayoutType.application,
        requiredPolicy: 'WaterCarriage.Members',
      }
    ]);
  };
}
