import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImoveisService {

  private readonly API = "https://localhost:5001/LocacaoDeImoveis/trazer";

  constructor(private http: HttpClient) { }

  Listar(): Observable<any> {
    let result = this.http.get<any>(this.API);
    return result;
  }

  Criar(usuario: any): Observable<any> {
    let result: Observable<any> = this.http.post<any>(this.API, usuario)
      return result;
  }
}
