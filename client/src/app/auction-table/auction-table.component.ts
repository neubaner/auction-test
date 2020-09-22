import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import Auction from '../auction/auction.model';

@Component({
  selector: 'app-auction-table',
  templateUrl: './auction-table.component.html',
  styleUrls: ['./auction-table.component.scss']
})
export class AuctionTableComponent implements AfterViewInit, OnChanges {
  displayedColumns: string[] = ['id', 'name', 'initialValue', 'isUsed', 'responsibleId', 'openingDate', 'closingDate', 'actions']

  @Input()
  auctions: Auction[]

  @Output()
  addAuctionEvent = new EventEmitter()

  @Output()
  editAuctionEvent = new EventEmitter<Auction>()

  @Output()
  deleteAuctionEvent = new EventEmitter<Auction>()

  dataSource: MatTableDataSource<Auction>

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  constructor() {
    this.dataSource = new MatTableDataSource(this.auctions)
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.auctions) {
      this.dataSource.data = changes.auctions.currentValue
    }
  }

  addNewAuction() {
    this.addAuctionEvent.emit()
  }

  editAuction(auction: Auction) {
    this.editAuctionEvent.emit(auction)
  }

  deleteAuction(auction: Auction) {
    this.deleteAuctionEvent.emit(auction)
  }

}
