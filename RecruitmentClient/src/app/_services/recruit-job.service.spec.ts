/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecruitJobService } from './recruit-job.service';

describe('Service: RecruitJob', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecruitJobService]
    });
  });

  it('should ...', inject([RecruitJobService], (service: RecruitJobService) => {
    expect(service).toBeTruthy();
  }));
});
