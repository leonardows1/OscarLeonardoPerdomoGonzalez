import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-halterofilia',
  templateUrl: './halterofilia.component.html'
})
export class FetchDataComponent {
  public halterofilias: Halterofilia[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Halterofilia[]>(baseUrl + 'wheaterforecast').subscribe(result => {
      this.halterofilias = result;
    }, error => console.error(error));
  }
}

interface Halterofilia {
  halterofiliaId: number;
  pais: string;
  deportista: Deportista;
  arranqueKg: number;
  envionKg: number;
  totalPesoKg: number;
}

interface Deportista {
  deportistaId: number;
  nombre: string;
  halterofilias?: Halterofilia[];
}
