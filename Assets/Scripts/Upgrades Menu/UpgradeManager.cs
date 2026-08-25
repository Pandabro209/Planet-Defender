using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
	public static UpgradeManager Instance;

	[Header("Testing")]
	public bool useInspectorValuesForTesting = false;


	// =========================================
	// FIRE RATE
	// =========================================

	[Header("Fire Rate")]
	public int fireRateLevel = 0;
	public int fireRateCost = 100;


	// =========================================
	// PIERCING
	// =========================================

	[Header("Piercing")]
	public int piercingLevel = 0;
	public int piercingCost = 100;


	// =========================================
	// JUMPSTART
	// =========================================

	[Header("Jumpstart")]
	public int jumpstartLevel = 0;
	public int jumpstartCost = 100;


	// =========================================
	// UI
	// =========================================

	[Header("UI")]
	public TMP_Text totalPointsText;

	[Header("Fire Rate UI")]
	public TMP_Text fireRateLevelText;
	public TMP_Text fireRateCostText;

	[Header("Piercing UI")]
	public TMP_Text piercingLevelText;
	public TMP_Text piercingCostText;

	[Header("Jumpstart UI")]
	public TMP_Text jumpstartLevelText;
	public TMP_Text jumpstartCostText;


	// =========================================
	// AWAKE
	// =========================================

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;

			LoadUpgrades();
		}
		else
		{
			Destroy(gameObject);
		}
	}


	// =========================================
	// START
	// =========================================

	private void Start()
	{
		if (ScoreManager.Instance != null)
		{
			UpdateUpgradeUI();
		}
		else
		{
			Debug.LogWarning(
				"ScoreManager doesn't exist! Start the game from the Main Menu."
			);
		}
	}


	// =========================================
	// FIRE RATE UPGRADE
	// =========================================

	public void BuyFireRateUpgrade()
	{
		if (ScoreManager.Instance == null)
		{
			Debug.LogWarning("ScoreManager doesn't exist!");
			return;
		}

		if (ScoreManager.Instance.totalPoints < fireRateCost)
		{
			Debug.Log("Not enough points for Fire Rate upgrade!");
			return;
		}

		// Spend points
		ScoreManager.Instance.totalPoints -= fireRateCost;

		// Increase level
		fireRateLevel++;

		// Increase cost by 1.5x
		fireRateCost =
			Mathf.RoundToInt(fireRateCost * 1.5f);

		SaveUpgrades();

		// Save total points
		PlayerPrefs.SetInt(
			"TotalPoints",
			ScoreManager.Instance.totalPoints
		);

		PlayerPrefs.Save();

		UpdateUpgradeUI();

		Debug.Log(
			"Fire Rate upgraded to level " +
			fireRateLevel
		);

		Debug.Log(
			"Next Fire Rate cost: " +
			fireRateCost
		);
	}


	// =========================================
	// PIERCING UPGRADE
	// =========================================

	public void BuyPiercingUpgrade()
	{
		if (ScoreManager.Instance == null)
		{
			Debug.LogWarning("ScoreManager doesn't exist!");
			return;
		}

		if (ScoreManager.Instance.totalPoints < piercingCost)
		{
			Debug.Log("Not enough points for Piercing upgrade!");
			return;
		}

		// Spend points
		ScoreManager.Instance.totalPoints -= piercingCost;

		// Increase level
		piercingLevel++;

		// Increase cost by 7.5x
		piercingCost =
			Mathf.RoundToInt(piercingCost * 7.5f);

		SaveUpgrades();

		// Save total points
		PlayerPrefs.SetInt(
			"TotalPoints",
			ScoreManager.Instance.totalPoints
		);

		PlayerPrefs.Save();

		UpdateUpgradeUI();

		Debug.Log(
			"Piercing upgraded to level " +
			piercingLevel
		);

		Debug.Log(
			"Next Piercing cost: " +
			piercingCost
		);
	}


	// =========================================
	// JUMPSTART UPGRADE
	// =========================================

	public void BuyJumpstartUpgrade()
	{
		if (ScoreManager.Instance == null)
		{
			Debug.LogWarning("ScoreManager doesn't exist!");
			return;
		}

		if (ScoreManager.Instance.totalPoints < jumpstartCost)
		{
			Debug.Log("Not enough points for Jumpstart upgrade!");
			return;
		}

		// Spend points
		ScoreManager.Instance.totalPoints -= jumpstartCost;

		// Increase level
		jumpstartLevel++;

		// Increase cost by 1.5x
		jumpstartCost =
			Mathf.RoundToInt(jumpstartCost * 1.5f);

		SaveUpgrades();

		// Save total points
		PlayerPrefs.SetInt(
			"TotalPoints",
			ScoreManager.Instance.totalPoints
		);

		PlayerPrefs.Save();

		UpdateUpgradeUI();

		Debug.Log(
			"Jumpstart upgraded to level " +
			jumpstartLevel
		);

		Debug.Log(
			"Next Jumpstart cost: " +
			jumpstartCost
		);
	}


	// =========================================
	// UPDATE UI
	// =========================================

	private void UpdateUpgradeUI()
	{
		// Total points
		if (ScoreManager.Instance != null &&
			totalPointsText != null)
		{
			totalPointsText.text =
				"Total Points: " +
				ScoreManager.Instance.totalPoints;
		}


		// Fire Rate
		if (fireRateLevelText != null)
		{
			fireRateLevelText.text =
				"Level: " +
				fireRateLevel;
		}

		if (fireRateCostText != null)
		{
			fireRateCostText.text =
				"Cost: " +
				fireRateCost;
		}


		// Piercing
		if (piercingLevelText != null)
		{
			piercingLevelText.text =
				"Level: " +
				piercingLevel;
		}

		if (piercingCostText != null)
		{
			piercingCostText.text =
				"Cost: " +
				piercingCost;
		}


		// Jumpstart
		if (jumpstartLevelText != null)
		{
			jumpstartLevelText.text =
				"Level: " +
				jumpstartLevel;
		}

		if (jumpstartCostText != null)
		{
			jumpstartCostText.text =
				"Cost: " +
				jumpstartCost;
		}
	}


	// =========================================
	// SAVE UPGRADES
	// =========================================

	private void SaveUpgrades()
	{
		PlayerPrefs.SetInt(
			"FireRateLevel",
			fireRateLevel
		);

		PlayerPrefs.SetInt(
			"FireRateCost",
			fireRateCost
		);


		PlayerPrefs.SetInt(
			"PiercingLevel",
			piercingLevel
		);

		PlayerPrefs.SetInt(
			"PiercingCost",
			piercingCost
		);


		PlayerPrefs.SetInt(
			"JumpstartLevel",
			jumpstartLevel
		);

		PlayerPrefs.SetInt(
			"JumpstartCost",
			jumpstartCost
		);

		PlayerPrefs.Save();
	}


	// =========================================
	// LOAD UPGRADES
	// =========================================

	private void LoadUpgrades()
	{
		if (useInspectorValuesForTesting)
		{
			Debug.Log(
				"TESTING MODE: Using Inspector upgrade values."
			);

			// Fire Rate
			PlayerPrefs.SetInt(
				"FireRateLevel",
				fireRateLevel
			);

			PlayerPrefs.SetInt(
				"FireRateCost",
				fireRateCost
			);


			// Piercing
			PlayerPrefs.SetInt(
				"PiercingLevel",
				piercingLevel
			);

			PlayerPrefs.SetInt(
				"PiercingCost",
				piercingCost
			);


			// Jumpstart
			PlayerPrefs.SetInt(
				"JumpstartLevel",
				jumpstartLevel
			);

			PlayerPrefs.SetInt(
				"JumpstartCost",
				jumpstartCost
			);

			PlayerPrefs.Save();

			return;
		}


		// Normal mode

		fireRateLevel =
			PlayerPrefs.GetInt(
				"FireRateLevel",
				0
			);

		fireRateCost =
			PlayerPrefs.GetInt(
				"FireRateCost",
				100
			);


		piercingLevel =
			PlayerPrefs.GetInt(
				"PiercingLevel",
				0
			);

		piercingCost =
			PlayerPrefs.GetInt(
				"PiercingCost",
				100
			);


		jumpstartLevel =
			PlayerPrefs.GetInt(
				"JumpstartLevel",
				0
			);

		jumpstartCost =
			PlayerPrefs.GetInt(
				"JumpstartCost",
				100
			);
	}


	// =========================================
	// RESET EVERYTHING
	// =========================================

	public void ResetAllProgress()
	{
		// Reset Fire Rate
		fireRateLevel = 0;
		fireRateCost = 100;

		// Reset Piercing
		piercingLevel = 0;
		piercingCost = 100;

		// Reset Jumpstart
		jumpstartLevel = 0;
		jumpstartCost = 100;


		// Reset total points
		if (ScoreManager.Instance != null)
		{
			ScoreManager.Instance.totalPoints = 0;
		}


		// Delete saved data
		PlayerPrefs.DeleteKey("FireRateLevel");
		PlayerPrefs.DeleteKey("FireRateCost");

		PlayerPrefs.DeleteKey("PiercingLevel");
		PlayerPrefs.DeleteKey("PiercingCost");

		PlayerPrefs.DeleteKey("JumpstartLevel");
		PlayerPrefs.DeleteKey("JumpstartCost");

		PlayerPrefs.DeleteKey("TotalPoints");
		PlayerPrefs.DeleteKey("HighScore");

		PlayerPrefs.Save();


		UpdateUpgradeUI();

		Debug.Log("ALL PROGRESS RESET!");
	}
}