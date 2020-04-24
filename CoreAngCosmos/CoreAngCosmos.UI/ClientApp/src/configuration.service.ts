import { HttpClient } from "@angular/common/http";
import { Injectable, APP_INITIALIZER  } from '@angular/core';

@Injectable()
export class ConfigurationService {
  constructor(private http: HttpClient) {
  }

  config: IAngularConfiguration;

  private getConfig() {
    return this.http.get<IAngularConfiguration>("/api/ConfigurationApi/GetConfiguration");
  }

  public loadConfig() {
    return new Promise((resolve, reject) => {
      this.getConfig()
        .subscribe(
          x => {
            this.config = x;
            resolve(true);
          },
          err => resolve(err)
        );
    });
  }
}

interface IAngularConfiguration {
  apiUrl: string;
}

export function configServiceInitFactory(configService: ConfigurationService) {
  return () => configService.loadConfig();
}

export const configServiceInitProvider = {
  provide: APP_INITIALIZER,
  useFactory: configServiceInitFactory,
  deps: [ConfigurationService],
  multi: true
}
