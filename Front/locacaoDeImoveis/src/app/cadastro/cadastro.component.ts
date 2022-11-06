import { ImoveisDTO } from './../Models/ImoveisDTO';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  imoveis: ImoveisDTO = {
    imovel_id: 0,
    descricao_imovel: '',
    status: 0,
    priority: 0,
    description: '',
    MyProperty: 0,
    endereco_imovel: '',
    cep_imovel: '',
    titulo_imovel: '',
    valor_imovel: ''
  }

  constructor() { }

  ngOnInit(): void {
  }

}
