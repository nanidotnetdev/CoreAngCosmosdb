"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ItemService = /** @class */ (function () {
    function ItemService(http, config) {
        this.http = http;
        this.config = config;
    }
    ItemService.prototype.getItems = function () {
        console.log("in get items" + this.config.apiUrl);
        return this.http.get(this.config.apiUrl + 'api/v1/ItemApi/Getall');
    };
    return ItemService;
}());
exports.ItemService = ItemService;
//# sourceMappingURL=items.service.js.map