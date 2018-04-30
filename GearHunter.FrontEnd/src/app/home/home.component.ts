import { Component, OnInit } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.sass"]
})
export class HomeComponent implements OnInit {
  advertisements: Array<any>;
  constructor(private http: Http) {
    this.http
      .get("http://localhost:50709/api/advertisements")
      .map(response => response.json())
      .subscribe(res => (this.advertisements = res));
  }

  ngOnInit() {}
}
