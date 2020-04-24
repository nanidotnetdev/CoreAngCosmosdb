"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ConfigurationService = /** @class */ (function () {
    function ConfigurationService(http) {
        this.http = http;
        this.getApiUrl();
    }
    ConfigurationService.prototype.getApiUrl = function () {
        var _this = this;
        return this.http.get("/api/ConfigurationApi/GetApiUrl").subscribe(function (result) {
            _this.apiUrl = result;
        }, function (error) { return console.log(error); });
    };
    return ConfigurationService;
}());
exports.ConfigurationService = ConfigurationService;
//# sourceMappingURL=configuration.service.js.map