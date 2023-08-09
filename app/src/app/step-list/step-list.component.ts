import { Component, Input } from '@angular/core';
import { Step } from '../DTO/recipe';

@Component({
  selector: 'app-step-list',
  templateUrl: './step-list.component.html',
  styleUrls: ['./step-list.component.css']
})

class StepListComponent {

  inputBind : string = "";

  @Input() public steps : Step[] = []

  addStep() : void {
    if(this.inputBind.length < 3) return
		
		this.steps.push(
			{
				order: this.steps.length,
				description: this.inputBind
			})
		this.inputBind = ""
  }


  removeStep(index : number) 
  {	
	this.steps = this.steps.filter(s => s.order != index)
 	this.steps.forEach((s, i) => s.order = i)
  }
}

export { StepListComponent, }
