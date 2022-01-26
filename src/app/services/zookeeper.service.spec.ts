import { TestBed } from '@angular/core/testing';

import { ZookeeperService } from './zookeeper.service';

describe('ZookeeperService', () => {
  let service: ZookeeperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZookeeperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
