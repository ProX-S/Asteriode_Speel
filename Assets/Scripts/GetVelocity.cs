using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GetVelocity : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger;//Adding the ControlOutput port variable.

	[DoNotSerialize] // No need to serialize ports
	public ValueInput gameObject { get; protected set; } // Adding the ValueInput variable for myValueA

	[DoNotSerialize] // No need to serialize ports
	public ValueOutput velocity; // Adding the ValueOutput variable for result

	private float resultValue;

	protected override void Definition()
	{
		//Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			//Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
			GameObject g = flow.GetValue<GameObject>(gameObject);
			Rigidbody r = g.GetComponent<Rigidbody>();

			if (r == null)
			{
				Debug.LogWarning($"No Rigidbody attached to this object! ({g.name}");
				resultValue = 0;
			}
			else
			{
				resultValue = r.linearVelocity.magnitude;
			}

			return outputTrigger;
		});

		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		//Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
		gameObject = ValueInput<GameObject>("gameObject", null).NullMeansSelf();

		//Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
		velocity = ValueOutput<float>("result", (flow) => { return resultValue; });

		Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
	}
}