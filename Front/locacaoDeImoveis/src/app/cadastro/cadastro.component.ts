import { ImoveisDTO } from './../Models/ImoveisDTO';
import { Component, Input, OnInit } from '@angular/core';
import { ImoveisService } from '../imoveis/imoveis.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  @Input() imoveis: ImoveisDTO = {
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

  constructor(private service: ImoveisService) { }

  ngOnInit(): void {
  }

  cadastrarImovel(){
    this.service.Criar(this.imoveis).subscribe(() => {
      alert("Imovel cadastrado!");
    })
  }

  trazerEnderecoImovel(){
    this.service.trazerEndereco(this.imoveis.cep_imovel).subscribe((enderecoRetorno) => {
      this.imoveis.endereco_imovel = enderecoRetorno.logradouro +","+
                                    enderecoRetorno.bairro +","+
                                    enderecoRetorno.localidade +","+
                                    enderecoRetorno.uf
    })
  }

}
