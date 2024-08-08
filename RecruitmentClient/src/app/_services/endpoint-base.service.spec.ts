/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EndpointBaseService } from './endpoint-base.service';

describe('Service: EndpointBase', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EndpointBaseService]
    });
  });

  it('should ...', inject([EndpointBaseService], (service: EndpointBaseService) => {
    expect(service).toBeTruthy();
  }));
});
