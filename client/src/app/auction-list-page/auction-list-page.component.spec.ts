import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionListPageComponent } from './auction-list-page.component';

describe('AuctionListPageComponent', () => {
  let component: AuctionListPageComponent;
  let fixture: ComponentFixture<AuctionListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionListPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
