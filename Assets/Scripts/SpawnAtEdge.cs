using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAtEdge : Unit
{
	[DoNotSerialize] // No need to serialize ports.
	public ControlInput inputTrigger; //Adding the ControlInput port variable

	[DoNotSerialize] // No need to serialize ports.
	public ControlOutput outputTrigger;//Adding the ControlOutput port variable.

	[DoNotSerialize] // No need to serialize ports
	public ValueInput spawnPadding; // Adding the ValueInput variable for myValueA

	[DoNotSerialize] // No need to serialize ports
	public ValueOutput spawnPosition; // Adding the ValueOutput variable for result

	private Vector3 resultValue;

	protected override void Definition()
	{
		//Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
		inputTrigger = ControlInput("inputTrigger", (flow) =>
		{
			//Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
			resultValue = GetRandomSpawnPosition(flow.GetValue<float>(spawnPadding));
			return outputTrigger;
		});

		//Making the ControlOutput port visible and setting its key.
		outputTrigger = ControlOutput("outputTrigger");

		//Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
		spawnPadding = ValueInput<float>("spawnPadding", 1f);
		//Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
		spawnPosition = ValueOutput<Vector3>("result", (flow) => { return resultValue; });

		Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
	}

	public Vector3 GetRandomSpawnPosition(float distanceOutside)
	{
		Camera camera = Camera.main;
		if (camera == null || !camera.orthographic)
		{
			Debug.LogError("Camera is null or not orthographic");
			return Vector3.zero;
		}

		float cameraHeight = camera.orthographicSize * 2;
		float cameraWidth = cameraHeight * camera.aspect;

		float halfWidth = cameraWidth / 2 + distanceOutside;
		float halfHeight = cameraHeight / 2 + distanceOutside;

		Vector3 cameraPosition = camera.transform.position;

		// Randomly choose which side of the camera to spawn
		int side = Random.Range(0, 4);

		switch (side)
		{
			case 0: // Top (now in Z)
				return new Vector3(
					Random.Range(cameraPosition.x - halfWidth, cameraPosition.x + halfWidth),
					0,
					cameraPosition.z + halfHeight
				);
			case 1: // Right
				return new Vector3(
					cameraPosition.x + halfWidth,
					0,
					Random.Range(cameraPosition.z - halfHeight, cameraPosition.z + halfHeight)
				);
			case 2: // Bottom (now in Z)
				return new Vector3(
					Random.Range(cameraPosition.x - halfWidth, cameraPosition.x + halfWidth),
					0,
					cameraPosition.z - halfHeight
				);
			case 3: // Left
				return new Vector3(
					cameraPosition.x - halfWidth,
					0,
					Random.Range(cameraPosition.z - halfHeight, cameraPosition.z + halfHeight)
				);
			default:
				return Vector3.zero; // This should never happen
		}
	}
}
