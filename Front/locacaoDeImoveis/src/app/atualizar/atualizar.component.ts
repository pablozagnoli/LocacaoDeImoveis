import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ImoveisService } from '../imoveis/imoveis.service';
import { ImoveisDTO } from '../Models/ImoveisDTO';

@Component({
  selector: 'app-atualizar',
  templateUrl: './atualizar.component.html',
  styleUrls: ['./atualizar.component.css']
})
export class AtualizarComponent implements OnInit {

  @Input() Imovel: ImoveisDTO = {
    imovel_id: 0,
    titulo_imovel: '',
    descricao_imovel: '',
    endereco_imovel: '',
    cep_imovel: '',
    valor_imovel: '',
    status: 0,
    priority: 0,
    description: '',
    MyProperty: 0
  };

  constructor(
    private service: ImoveisService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.BuscarImovel(parseInt(id!));
  }

  AtualizarImovel(){
    const id = this.route.snapshot.paramMap.get('id');

    this.service.Atualizar(parseInt(id!), this.Imovel).subscribe(() => {
      alert("Imovel Atualizado!")
    });
  }

  DeletarImovel(){
    const id = this.route.snapshot.paramMap.get('id');

    this.service.Deletar(parseInt(id!)).subscribe(() => {
      alert("Imovel Deletado!")
    });
  }

  BuscarImovel(id: number){
    this.service.ListarUm(id).subscribe((imovelRetorno) => {
      this.Imovel = imovelRetorno
    });
  }

  trazerEnderecoImovel(){
    this.service.trazerEndereco(this.Imovel.cep_imovel).subscribe((enderecoRetorno) => {
      this.Imovel.endereco_imovel = enderecoRetorno.logradouro +","+
                                    enderecoRetorno.bairro +","+
                                    enderecoRetorno.localidade +","+
                                    enderecoRetorno.uf
    })
  }
}
