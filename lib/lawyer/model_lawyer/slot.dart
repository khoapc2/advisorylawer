class SlotDTO {
  int id;
  int bookingId;
  String startAt;
  String endAt;
  int price;
  int lawyerId;

  SlotDTO(
      {required this.id,
      required this.bookingId,
      required this.startAt,
      required this.endAt,
      required this.price,
      required this.lawyerId});

  factory SlotDTO.fromJson(Map<String, dynamic> json) {
    return SlotDTO(
      id : json['id'],
      bookingId : json['booking_id'],
      startAt : json['start_at'],
      endAt : json['end_at'],
      price : json['price'],
      lawyerId : json['lawyer_id']
    );
    
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['booking_id'] = this.bookingId;
    data['start_at'] = this.startAt;
    data['end_at'] = this.endAt;
    data['price'] = this.price;
    data['lawyer_id'] = this.lawyerId;
    return data;
  }
}
