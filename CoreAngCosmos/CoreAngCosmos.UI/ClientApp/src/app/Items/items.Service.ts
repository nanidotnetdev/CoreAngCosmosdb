import { HttpClient } from '@angular/common/http';
import { Item } from "./items.component";
import { ConfigurationService } from "../../configuration.service";
import { Injectable } from '@angular/core';

@Injectable()
export class ItemService {
  constructor(private http: HttpClient, private configService: ConfigurationService) {
    
  }

  getItems() {
    console.log(this.configService)
    console.log(this.configService.config)
    return this.http.get<Item[]>(this.configService.config.apiUrl + 'api/v1/ItemApi/Getall');
  }
}
