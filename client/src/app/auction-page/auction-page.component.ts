import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuctionDialogDeleteComponent } from '../auction-dialog-delete/auction-dialog-delete.component';
import { AuctionDialogComponent } from '../auction-dialog/auction-dialog.component';
import { AuctionDialogModel } from '../auction-dialog/auction-dialog.model';
import Auction from '../auction/auction.model';
import { AuctionService } from '../auction/auction.service';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-auction-list-page',
  templateUrl: './auction-page.component.html',
  styleUrls: ['./auction-page.component.scss']
})
export class AuctionPageComponent {
  auctions: Auction[] = []

  constructor(
    private auctionService: AuctionService,
    private authService: AuthService,
    private router: Router,
    private dialog: MatDialog) {

    this.getAllAuctions()
  }

  logout() {
    this.authService.logout()
    this.router.navigate(['login'])
  }

  getAllAuctions() {
    this.auctionService.getAll().subscribe(result => {
      this.auctions = result
    })
  }

  addNewAuction() {
    const data: AuctionDialogModel = {
      title: 'Create Auction',
      auction: {}
    }

    const dialogRef = this.dialog.open(AuctionDialogComponent, {
      data
    })

    dialogRef.afterClosed().subscribe((auction: Auction) => {
      console.log(auction)

      this.auctionService.create(auction).subscribe(() => {
        this.getAllAuctions()
      })
    })
  }

  editAuction(auction: Auction) {
    const data: AuctionDialogModel = {
      title: 'Edit Auction',
      auction
    }

    const dialogRef = this.dialog.open(AuctionDialogComponent, {
      data
    })

    dialogRef.afterClosed().subscribe((auction: Auction) => {
      this.auctionService.update(auction).subscribe(() => {
        this.getAllAuctions()
      })
    })
  }

  deleteAuction(auction: Auction) {
    const dialogRef = this.dialog.open(AuctionDialogDeleteComponent)

    dialogRef.afterClosed().subscribe((shouldDelete: boolean) => {
      if (shouldDelete) {
        this.auctionService.delete(auction.id).subscribe(() => {
          this.getAllAuctions()
        })
      }
    })
  }
}
