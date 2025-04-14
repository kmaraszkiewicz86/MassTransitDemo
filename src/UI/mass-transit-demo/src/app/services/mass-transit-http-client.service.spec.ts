import { TestBed } from '@angular/core/testing';

import { MassTransitHttpClientService } from './mass-transit-http-client.service';

describe('MassTransitHttpClientService', () => {
  let service: MassTransitHttpClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MassTransitHttpClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
