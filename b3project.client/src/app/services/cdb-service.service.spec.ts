import { TestBed } from '@angular/core/testing';

import { CdbServiceService } from './cdb-service.service';

describe('CdbServiceService', () => {
  let service: CdbServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CdbServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
