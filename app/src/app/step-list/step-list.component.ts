import { Component } from '@angular/core';

@Component({
  selector: 'app-step-list',
  templateUrl: './step-list.component.html',
  styleUrls: ['./step-list.component.css']
})

class StepListComponent {

  inputBind : string = "";

  steps : Step[] = []

  addStep() : void {
    if(this.inputBind.length < 3) return
		
		this.steps.push(
			{
				id: this.steps.length,
				description: this.inputBind
			})
		this.inputBind = ""
  }


  removeStep(index : number) 
  {	
	this.steps = this.steps.filter(s => s.id != index)
 	this.steps.forEach((s, i) => s.id = i)
  }
}

interface Step
{
  id: number;
  description: string
}

export { StepListComponent, }
