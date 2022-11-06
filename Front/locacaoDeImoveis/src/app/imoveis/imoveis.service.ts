import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImoveisService {

  private readonly ROTAGETALL = "https://localhost:5001/LocacaoDeImoveis/trazer";
  private readonly ROTAGETONE = "https://localhost:5001/LocacaoDeImoveis/trazer/";
  private readonly ROTAATUALIZARONE = "https://localhost:5001/LocacaoDeImoveis/atualizar/";
  private readonly ROTADELETEONE = "https://localhost:5001/LocacaoDeImoveis/deletar/";
  private readonly ROTAGETENDERECOIMOVEL = "https://localhost:5001/LocacaoDeImoveis/endereco/";
  private readonly ROTAPOST = "https://localhost:5001/LocacaoDeImoveis/criar";

  constructor(private http: HttpClient) { }


  Criar(imovel: any): Observable<any> {
    let result: Observable<any> = this.http.post<any>(this.ROTAPOST, imovel)
      return result;
  }

  Listar(): Observable<any> {
    let result = this.http.get<any>(this.ROTAGETALL);
    return result;
  }

  ListarUm(id: number): Observable<any> {
    let result = this.http.get<any>(this.ROTAGETONE + id);
    return result;
  }

  trazerEndereco(cep: string): Observable<any> {
    let result = this.http.get<any>(this.ROTAGETENDERECOIMOVEL + cep);
    return result;
  }

  Atualizar(id: number, imovel: any): Observable<any> {
    let result = this.http.put<any>(this.ROTAATUALIZARONE + id, imovel);
    return result;
  }

  Deletar(id: number): Observable<any> {
    let result = this.http.delete<any>(this.ROTADELETEONE + id);
    return result;
  }
}
