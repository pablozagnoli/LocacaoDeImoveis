import { Component, OnInit } from '@angular/core';
import { ImoveisService } from './imoveis.service';

@Component({
  selector: 'app-imoveis',
  templateUrl: './imoveis.component.html',
  styleUrls: ['./imoveis.component.css']
})
export class ImoveisComponent implements OnInit {

  constructor(private service: ImoveisService) { }

  ngOnInit(): void {
  }

  buscarImoveis(){
    this.service.Listar();
  }
}
