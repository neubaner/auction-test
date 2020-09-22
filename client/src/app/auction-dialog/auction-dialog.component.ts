import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog'
import { AuctionDialogModel } from './auction-dialog.model';

@Component({
  selector: 'app-auction-dialog',
  templateUrl: './auction-dialog.component.html',
  styleUrls: ['./auction-dialog.component.scss']
})
export class AuctionDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: AuctionDialogModel) { }
}
