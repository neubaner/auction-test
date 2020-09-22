export default interface Auction {
  id: string
  name: string
  initialValue: number
  isUsed: boolean
  responsibleId: string
  openingDate: string
  closingDate?: string
}