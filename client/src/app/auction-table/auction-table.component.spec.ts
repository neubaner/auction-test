import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionTableComponent } from './auction-table.component';

describe('AuctionTableComponent', () => {
  let component: AuctionTableComponent;
  let fixture: ComponentFixture<AuctionTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
