import { Component } from '@angular/core';
import { ItemService } from "./items.service";

@Component({
  selector: 'items',
  templateUrl: './items.component.html'
})

export class ItemsComponent {

  public items: Item[];

  constructor(itemService: ItemService) {
    itemService.getItems().subscribe(
          data => { this.items = data },
            error => console.error(error),
            () => console.log('done loading')
    );
  }
}

export interface Item {
  name: string;
  description: string;
  isComplete: boolean;
  completedby: string;
  completeddate: Date;
  createdby: string;
  createdDate: Date;
  updatedBy: string;
  updateddate: Date;
}
