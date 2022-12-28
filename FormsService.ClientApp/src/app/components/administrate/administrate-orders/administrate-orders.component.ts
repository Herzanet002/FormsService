import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {Order} from "../../../models/Order";
import {DataOrdersService} from "../../../services/data-orders.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-administrate-orders',
  templateUrl: './administrate-orders.component.html',
  styleUrls: ['./administrate-orders.component.css']
})
export class AdministrateOrdersComponent implements OnInit{
  orders: Order[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedOrder: Order|null = null;
  isNewRecord: boolean = false;
  constructor(private dataOrdersService: DataOrdersService, private toast: ToastrService) {
    this.orders = new Array<Order>();
  }

  private getOrders(){
    this.dataOrdersService.getOrders().subscribe((data:Order[]) => {
      return this.orders = data});
  }

  public loadTemplate(order: Order) {
    return this.editedOrder && this.editedOrder.id === order.id? this.editTemplate: this.readOnlyTemplate;
  }
  saveOrder() {
      this.dataOrdersService.updateOrder(this.editedOrder as Order).subscribe(_ => {
        this.toast.success('Данные успешно обновлены')
          this.getOrders();
      });
      this.editedOrder = null;
  }

  public editOrder(order: Order) {
    this.editedOrder={
      id: order.id,
      personId: order.personId,
      location: order.location,
      dateForming: order.dateForming
    }
  }

  public deleteOrder(order: Order) {
    if(confirm(`Действительно удалить заказ ${order.id} ?`))
    this.dataOrdersService.deleteOrder(order.id).subscribe(_ => {
        this.getOrders();
      this.toast.info("Данные успешно удалены")
    });
  }
  cancel() {
    if (this.isNewRecord) {
      this.orders.pop();
      this.isNewRecord = false;
    }
    this.editedOrder = null;
  }
  ngOnInit(): void {
    this.getOrders();
  }
}
