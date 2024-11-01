using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpdateXPosition : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger;//Adding the ControlOutput port variable.

	[DoNotSerialize] // No need to serialize ports
	public ValueInput transform { get; protected set; } // Adding the ValueInput variable for myValueA
	public ValueInput newX; // Adding the ValueInput variable for myValueA

	[DoNotSerialize] // No need to serialize ports
	public ValueOutput updatedVector; // Adding the ValueOutput variable for result

	private Vector3 resultValue;

	protected override void Definition()
	{
		//Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			//Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
			Transform t = flow.GetValue<Transform>(transform);
			resultValue = t.position;
			resultValue.x = flow.GetValue<float>(newX);
			t.position = resultValue;

			return outputTrigger;
		});

		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		//Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
		transform = ValueInput<Transform>("transform", null).NullMeansSelf();
		newX = ValueInput<float>("newX", 0f);

		//Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
		updatedVector = ValueOutput<Vector3>("result", (flow) => { return resultValue; });

		Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
	}
}

public class UpdateYPosition : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger;//Adding the ControlOutput port variable.

	[DoNotSerialize] // No need to serialize ports
	public ValueInput transform { get; protected set; } // Adding the ValueInput variable for myValueA
	public ValueInput newY; // Adding the ValueInput variable for myValueA

	[DoNotSerialize] // No need to serialize ports
	public ValueOutput updatedVector; // Adding the ValueOutput variable for result

	private Vector3 resultValue;

	protected override void Definition()
	{
		//Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			//Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
			Transform t = flow.GetValue<Transform>(transform);
			resultValue = t.position;
			resultValue.z = flow.GetValue<float>(newY);
			t.position = resultValue;

			return outputTrigger;
		});

		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		//Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
		transform = ValueInput<Transform>("transform", null).NullMeansSelf();
		newY = ValueInput<float>("newY", 0f);

		//Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
		updatedVector = ValueOutput<Vector3>("result", (flow) => { return resultValue; });

		Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
	}
}

public class UpdateZPosition : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger;//Adding the ControlOutput port variable.

	[DoNotSerialize] // No need to serialize ports
	public ValueInput transform { get; protected set; } // Adding the ValueInput variable for myValueA
	public ValueInput newZ; // Adding the ValueInput variable for myValueA

	[DoNotSerialize] // No need to serialize ports
	public ValueOutput updatedVector; // Adding the ValueOutput variable for result

	private Vector3 resultValue;

	protected override void Definition()
	{
		//Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			//Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
			Transform t = flow.GetValue<Transform>(transform);
			resultValue = t.position;
			resultValue.z = flow.GetValue<float>(newZ);
			t.position = resultValue;

			return outputTrigger;
		});

		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		//Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
		transform = ValueInput<Transform>("transform", null).NullMeansSelf();
		newZ = ValueInput<float>("newZ", 0f);

		//Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
		updatedVector = ValueOutput<Vector3>("result", (flow) => { return resultValue; });

		Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
	}
}