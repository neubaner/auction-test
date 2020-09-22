import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionDialogDeleteComponent } from './auction-dialog-delete.component';

describe('AuctionDialogDeleteComponent', () => {
  let component: AuctionDialogDeleteComponent;
  let fixture: ComponentFixture<AuctionDialogDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionDialogDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionDialogDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
