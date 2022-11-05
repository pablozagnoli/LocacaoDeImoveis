import { ImoveisService } from './../imoveis/imoveis.service';
import { ImoveisDTO } from './../Models/ImoveisDTO';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  listaImoveis: ImoveisDTO[] = [];

  constructor(private service: ImoveisService) { }

  ngOnInit(): void {
    this.ListarImoveis();
  }

  ListarImoveis(){
    this.service.Listar().subscribe((imoveis) => {
      this.listaImoveis = imoveis
    });
  }

}
