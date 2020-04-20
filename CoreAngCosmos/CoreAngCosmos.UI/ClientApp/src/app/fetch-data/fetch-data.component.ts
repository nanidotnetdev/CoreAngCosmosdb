import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Item[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Item[]>(apiUrl + 'api/v1/ItemApi/Getall').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Item {
  name: string;
  description: string;
}
