/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecruitService } from './recruit.service';

describe('Service: Recruit', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecruitService]
    });
  });

  it('should ...', inject([RecruitService], (service: RecruitService) => {
    expect(service).toBeTruthy();
  }));
});
