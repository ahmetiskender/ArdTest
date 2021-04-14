import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
    providedIn:'root',
})

export class UserService{
    constructor (
        @Inject('apiUrl') private apiUrl,
        private http: HttpClient
    ) {}



    addUser(obj){
        const httpOptions = {
            headers: new HttpHeaders({'Content-Type': 'application/json'})
          }
        return this.http.post(this.apiUrl+'/AddUser',obj,httpOptions);
    }

    getAllUsers(){
        return this.http.get(this.apiUrl+'/GetAllUser');
    }

    getUser(id){
        return this.http.get(this.apiUrl+'/GetUser?id='+id)
    }

    updateUser(obj){
        const httpOptions = {
            headers: new HttpHeaders({'Content-Type': 'application/json'})
          }
        return this.http.put(this.apiUrl+'/UpdateUser',obj,httpOptions);
    }

    deleteUser(id){
        return this.http.delete(this.apiUrl+'/DeleteUser?id='+id);
    }
}