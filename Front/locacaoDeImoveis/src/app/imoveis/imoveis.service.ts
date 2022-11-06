import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImoveisService {

  private readonly ROTAGETALL = "https://localhost:5001/LocacaoDeImoveis/trazer";
  private readonly ROTAPOST = "https://localhost:5001/LocacaoDeImoveis/criar";

  constructor(private http: HttpClient) { }

  Listar(): Observable<any> {
    let result = this.http.get<any>(this.ROTAGETALL);
    return result;
  }

  Criar(imovel: any): Observable<any> {
    let result: Observable<any> = this.http.post<any>(this.ROTAPOST, imovel)
      return result;
  }
}
