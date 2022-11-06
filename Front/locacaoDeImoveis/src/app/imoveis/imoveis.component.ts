import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ImoveisDTO } from '../Models/ImoveisDTO';
import { ImoveisService } from './imoveis.service';

@Component({
  selector: 'app-imoveis',
  templateUrl: './imoveis.component.html',
  styleUrls: ['./imoveis.component.css']
})
export class ImoveisComponent implements OnInit {

  listaImoveis: ImoveisDTO[] = [];
  id = this.route.snapshot.paramMap.get('id');

  constructor(
    private service: ImoveisService,
    private route: ActivatedRoute
    ) { }


  ngOnInit(): void {
    this.ListarImoveis();
  }

  ListarImoveis(){
    this.service.Listar().subscribe((imoveis) => {
      this.listaImoveis = imoveis
    });
  }
}
