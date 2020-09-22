import Auction from '../auction/auction.model';


export interface AuctionDialogModel {
  title: string;
  auction: Partial<Auction>;
}
