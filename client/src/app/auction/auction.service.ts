import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { environment } from '../../environments/environment'
import Auction from './auction.model';

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  API_URL = `${environment.apiUrl}/auction`

  constructor(
    private authService: AuthService,
    private httpClient: HttpClient) { }

  get options() {
    return {
      headers: {
        Authorization: `Bearer ${this.authService.getToken()}`
      }
    }
  }

  create(auction: Omit<Auction, 'id'>) {
    return this.httpClient.post<Auction>(this.API_URL, auction, this.options)
  }

  update(auction: Auction) {
    return this.httpClient.put<Auction>(`${this.API_URL}/${auction.id}`, auction, this.options)
  }

  getById(id: string) {
    return this.httpClient.get<Auction>(`${this.API_URL}/${id}`, this.options)
  }

  getAll() {
    return this.httpClient.get<Auction[]>(this.API_URL, this.options)
  }

  delete(id: string) {
    return this.httpClient.delete(`${this.API_URL}/${id}`, this.options)
  }
}
