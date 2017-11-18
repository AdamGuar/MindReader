"""
==========================================
Fuzzy Control Systems: Brain wave
==========================================

"""

import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl
import sys

#   !!!!!!! Input variables and their membership functions :

# ============== Variable initialization


alpha = ctrl.Antecedent(np.arange(0, 10001, 1), 'alpha')
beta = ctrl.Antecedent(np.arange(0, 10001, 1), 'beta')
gamma = ctrl.Antecedent(np.arange(0, 10001, 1), 'gamma')

# ==== Membership function of input variables

alpha['low'] = fuzz.trapmf(alpha.universe, [0, 0, 5, 7])
alpha['optimal'] = fuzz.trapmf(alpha.universe, [5, 7, 150, 470])
alpha['high'] = fuzz.trapmf(alpha.universe, [150, 470, 1000, 10000])

beta['low'] = fuzz.trapmf(beta.universe, [0, 0, 5, 7])
beta['optimal'] = fuzz.trapmf(beta.universe, [5, 7, 150, 470])
beta['high'] = fuzz.trapmf(beta.universe, [150, 470, 1000, 10000])

gamma['low'] = fuzz.trapmf(gamma.universe, [0, 0, 60, 80])
gamma['optimal'] = fuzz.trapmf(gamma.universe, [60, 80, 700, 800])
gamma['high'] = fuzz.trapmf(gamma.universe, [700, 800, 1000, 10000])

# !!!!!!!!!!! Output variables and their membership functions :
# ============== Variable initialization


activity = ctrl.Consequent(np.arange(0, 101, 1), 'activity')

# ==== Membership function of input variables
activity['brain-injuries'] = fuzz.trapmf(activity.universe, [0, 0, 15, 20])
activity['daydreaming'] = fuzz.trapmf(activity.universe, [15, 20, 35, 40])
activity['optimal-relaxed'] = fuzz.trapmf(activity.universe, [35, 40, 55, 60])
activity['adrenaline-focused'] = fuzz.trapmf(activity.universe, [55, 60, 75, 80])
activity['adhd-anxiety'] = fuzz.trapmf(activity.universe, [75, 80, 95, 100])

""" 
Fuzzy rules
-----------
"""

# rule1 = ctrl.Rule(quality['poor'] | service['poor'], tip['low'])
# rule2 = ctrl.Rule(service['average'], tip['medium'])
# rule3 = ctrl.Rule(service['good'] | quality['good'], tip['high'])

rule1 = ctrl.Rule(alpha['low'] & beta['low'] & gamma['low'], activity['adhd-anxiety'])
rule2 = ctrl.Rule(alpha['low'] & beta['low'] & gamma['optimal'], activity['adhd-anxiety'])
rule3 = ctrl.Rule(alpha['low'] & beta['low'] & gamma['high'], activity['adrenaline-focused'])
rule4 = ctrl.Rule(alpha['low'] & beta['optimal'] & gamma['low'], activity['adrenaline-focused'])
rule5 = ctrl.Rule(alpha['low'] & beta['optimal'] & gamma['optimal'], activity['optimal-relaxed'])
rule6 = ctrl.Rule(alpha['low'] & beta['optimal'] & gamma['high'], activity['optimal-relaxed'])
rule7 = ctrl.Rule(alpha['low'] & beta['high'] & gamma['low'], activity['adrenaline-focused'])
rule8 = ctrl.Rule(alpha['low'] & beta['high'] & gamma['optimal'], activity['adrenaline-focused'])
rule9 = ctrl.Rule(alpha['low'] & beta['high'] & gamma['high'], activity['adrenaline-focused'])
rule10 = ctrl.Rule(alpha['optimal'] & beta['low'] & gamma['low'], activity['daydreaming'])
rule11 = ctrl.Rule(alpha['optimal'] & beta['low'] & gamma['optimal'], activity['optimal-relaxed'])
rule12 = ctrl.Rule(alpha['optimal'] & beta['low'] & gamma['high'], activity['optimal-relaxed'])
rule13 = ctrl.Rule(alpha['optimal'] & beta['optimal'] & gamma['low'], activity['optimal-relaxed'])
rule14 = ctrl.Rule(alpha['optimal'] & beta['optimal'] & gamma['optimal'], activity['optimal-relaxed'])
rule15 = ctrl.Rule(alpha['optimal'] & beta['optimal'] & gamma['high'], activity['optimal-relaxed'])
rule16 = ctrl.Rule(alpha['optimal'] & beta['high'] & gamma['low'], activity['adrenaline-focused'])
rule17 = ctrl.Rule(alpha['optimal'] & beta['high'] & gamma['optimal'], activity['adrenaline-focused'])
rule18 = ctrl.Rule(alpha['optimal'] & beta['high'] & gamma['high'], activity['adhd-anxiety'])
rule19 = ctrl.Rule(alpha['high'] & beta['low'] & gamma['low'], activity['daydreaming'])
rule20 = ctrl.Rule(alpha['high'] & beta['low'] & gamma['optimal'], activity['daydreaming'])
rule21 = ctrl.Rule(alpha['high'] & beta['low'] & gamma['high'], activity['adhd-anxiety'])
rule22 = ctrl.Rule(alpha['high'] & beta['optimal'] & gamma['low'], activity['adhd-anxiety'])
rule23 = ctrl.Rule(alpha['high'] & beta['optimal'] & gamma['optimal'], activity['adrenaline-focused'])
rule24 = ctrl.Rule(alpha['high'] & beta['optimal'] & gamma['high'], activity['adhd-anxiety'])
rule25 = ctrl.Rule(alpha['high'] & beta['high'] & gamma['low'], activity['adhd-anxiety'])
rule26 = ctrl.Rule(alpha['high'] & beta['high'] & gamma['optimal'], activity['adhd-anxiety'])
rule27 = ctrl.Rule(alpha['high'] & beta['high'] & gamma['high'], activity['adhd-anxiety'])

activity_ctrl = ctrl.ControlSystem(
    [rule1, rule2, rule3, rule4, rule5, rule6, rule7, rule8, rule9, rule10, rule11, rule12, rule13, rule14, rule15,
     rule16, rule17, rule18, rule19, rule20, rule21, rule22, rule23, rule24, rule25, rule26, rule27, ])

activity_output = ctrl.ControlSystemSimulation(activity_ctrl)

"""
We can now simulate our control system by simply specifying the inputs
and calling the ``compute`` method.  Suppose we rated the quality 6.5 out of 10
and the service 9.8 of 10.
"""
# Pass inputs to the ControlSystem using Antecedent labels with Pythonic API
# Note: if you like passing many inputs all at once, use .inputs(dict_of_data)

alphaInput = float(sys.argv[1])
betInput = float(sys.argv[2])
gammaInput = float(sys.argv[3])

activity_output.input['alpha'] = alphaInput
activity_output.input['beta'] = betInput
activity_output.input['gamma'] = gammaInput


# Crunch the numbers
activity_output.compute()

"""
Once computed, we can view the result as well as visualize it.
"""
print(activity_output.output['activity'])

def fuzzOutput(output):
    outputstate = ['Brain injuries','Daydreaming/Sleepy','Normal behaviour','Adrenaline-rush/focused','Anxiety state']
    if output < 20 : print(outputstate[0])
    elif output < 40 : print(outputstate[1])
    elif output < 60 : print(outputstate[2])
    elif output < 80 : print(outputstate[3])
    elif output < 100 : print(outputstate[4])

fuzactivity = sys.argv[4]

if fuzactivity == "-fuzz":
    fuzzOutput(activity_output.output['activity'])
else:
    print(activity_output.output['activity'])



