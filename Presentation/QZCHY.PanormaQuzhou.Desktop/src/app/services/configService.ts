
import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService{
    apiUrl:string;

    constructor(){
        this.apiUrl="http://abcde.vaiwan.com/api/"
    }

    getApiUrl():string{
        return this.apiUrl;
    }

    getClinetId():string{
        return "";
    }
}