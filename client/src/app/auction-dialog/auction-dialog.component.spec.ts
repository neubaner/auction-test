import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionDialogComponent } from './auction-dialog.component';

describe('AuctionDialogComponent', () => {
  let component: AuctionDialogComponent;
  let fixture: ComponentFixture<AuctionDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
